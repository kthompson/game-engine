using CppSharp;
using CppSharp.AST;
using CppSharp.Passes;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using CppSharp.AST.Extensions;
using CppSharp.Generators;

namespace SharpSDLGen
{
    internal class SDL : ILibrary
    {
        public void Setup(Driver driver)
        {
            var options = driver.Options;
            var module = options.AddModule("SDL2");
            module.OutputNamespace = "SharpSDL";
            module.Headers.Add("SDL.h");
            options.OutputDir = GetSourceDirectory("SharpSDL");

            var parserOptions = driver.ParserOptions;

            var sdlDirectory = GetSourceDirectory("SDL-2.0");
            var sdlInclude = Path.Combine(sdlDirectory, "include");
            parserOptions.AddIncludeDirs(sdlInclude);
            driver.Options.GenerateSingleCSharpFile = false;
        }

        public void SetupPasses(Driver driver)
        {
            driver.Context.TranslationUnitPasses.RemovePrefix("SDL_");
            driver.Context.TranslationUnitPasses.RemovePrefix("SCANCODE_");
            driver.Context.TranslationUnitPasses.RemovePrefix("SDLK_");
            driver.Context.TranslationUnitPasses.RemovePrefix("KMOD_");
            driver.Context.TranslationUnitPasses.RemovePrefix("LOG_CATEGORY_");

            driver.Options.GenerateName = unit =>
                Regex.Replace(unit.FileNameWithoutExtension, "_[a-z]", m => m.Value[1].ToString().ToUpper());
        }

        public void Preprocess(Driver driver, ASTContext ctx)
        {
            ctx.IgnoreEnumWithMatchingItem("SDL_FALSE");
            ctx.IgnoreEnumWithMatchingItem("DUMMY_ENUM_VALUE");

            ctx.SetNameOfEnumWithMatchingItem("SDL_SCANCODE_UNKNOWN", "ScanCode");
            ctx.SetNameOfEnumWithMatchingItem("SDLK_UNKNOWN", "Key");
            ctx.SetNameOfEnumWithMatchingItem("KMOD_NONE", "KeyModifier");
            ctx.SetNameOfEnumWithMatchingItem("SDL_LOG_CATEGORY_CUSTOM", "LogCategory");

            ctx.GenerateEnumFromMacros("InitFlags", "SDL_INIT_(.*)").SetFlags();
            ctx.GenerateEnumFromMacros("Endianness", "SDL_(.*)_ENDIAN");
            ctx.GenerateEnumFromMacros("InputState", "SDL_RELEASED", "SDL_PRESSED");
            ctx.GenerateEnumFromMacros("AlphaState", "SDL_ALPHA_(.*)");
            ctx.GenerateEnumFromMacros("HatState", "SDL_HAT_(.*)");

            ctx.IgnoreHeadersWithName("SDL_atomic*");
            ctx.IgnoreHeadersWithName("SDLAtomic*");
            ctx.IgnoreHeadersWithName("SDL_endian*");
            ctx.IgnoreHeadersWithName("SDL_main*");
            ctx.IgnoreHeadersWithName("SDL_mutex*");
            ctx.IgnoreHeadersWithName("SDL_stdinc*");
            ctx.IgnoreHeadersWithName("SDL_error");
            ctx.IgnoreHeadersWithName("SDL_rwops");

            ctx.IgnoreEnumWithMatchingItem("SDL_ENOMEM");
            ctx.IgnoreFunctionWithName("SDL_Error");

            //ctx.SetFunctionParameterUsage("SDL_PollEvent", 1, ParameterUsage.Out);
            var pollEvent = ctx.FindFunction("SDL_PollEvent").First();

            var eventParam = pollEvent.Parameters[0];
            eventParam.Usage = ParameterUsage.Out;
            //eventParam.Kind = ParameterKind.IndirectReturnType;

            ctx.IgnoreClassWithName("Windowsio");

            //var typeDefs = ctx.TranslationUnits.SelectMany(tu => tu.Typedefs).ToList();

            //var kmType = ctx.FindTypedef("SDL_Keymod").First();
            //var keysym = ctx.FindClass("SDL_Keysym").First();
            //var modField = keysym.Fields.Find(f => f.Name == "mod");
            //modField.QualifiedType = new QualifiedType(new TypedefType(kmType));
            //ctx.SetClassAsValueType();
        }

        public void Postprocess(Driver driver, ASTContext ctx)
        {
            ctx.SetNameOfEnumWithName("PIXELTYPE", "PixelType");
            ctx.SetNameOfEnumWithName("BITMAPORDER", "BitmapOrder");
            ctx.SetNameOfEnumWithName("PACKEDORDER", "PackedOrder");
            ctx.SetNameOfEnumWithName("ARRAYORDER", "ArrayOrder");
            ctx.SetNameOfEnumWithName("PACKEDLAYOUT", "PackedLayout");
            ctx.SetNameOfEnumWithName("PIXELFORMAT", "PixelFormats");
            ctx.SetNameOfEnumWithName("assert_state", "AssertState");
            ctx.SetClassBindName("assert_data", "AssertData");
            ctx.SetNameOfEnumWithName("eventaction", "EventAction");
            ctx.SetNameOfEnumWithName("LOG_CATEGORY", "LogCategory");

            var workItems = ctx.TranslationUnits.Where(unit => unit.FileName.StartsWith("SDL_")).ToList();
            foreach (var translationUnit in workItems)
            {
                var newTu = new TranslationUnit()
                {
                    Macros = translationUnit.Macros,
                    Access = translationUnit.Access,
                    Module = translationUnit.Module,
                    IsSystemHeader = translationUnit.IsSystemHeader,
                    IsInline = translationUnit.IsInline,
                    Declarations = translationUnit.Declarations,
                    TypeReferences = translationUnit.TypeReferences,
                    Anonymous = translationUnit.Anonymous,
                    IsExternCContext = translationUnit.IsExternCContext,
                    IsAnonymous = translationUnit.IsAnonymous,
                    FilePath = "SDL" + translationUnit.FileName.Substring(4, 1).ToUpper() + translationUnit.FileName.Substring(5),
                };
                ctx.TranslationUnits.Remove(translationUnit);
                ctx.TranslationUnits.Add(newTu);
            }

            //var pollEvent = ctx.FindFunction("SDL_PollEvent").First();
        }

        public static string GetSourceDirectory(string name)
        {
            var directory = Directory.GetParent(Directory.GetCurrentDirectory());

            while (directory != null)
            {
                var path = Path.Combine(directory.FullName, name);

                if (Directory.Exists(path))
                    return path;

                directory = directory.Parent;
            }

            throw new Exception($"SDL directory for project '{name}' was not found");
        }
    }

    internal static class Program
    {
        public static void Main(string[] args)
        {
            ConsoleDriver.Run(new SDL());
        }
    }
}