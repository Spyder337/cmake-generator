// See https://aka.ms/new-console-template for more information

using CMakeGenerator;

string templateDir = Directory.GetCurrentDirectory();
string baseTemplateDir = Path.Combine(templateDir, "templates", "base-cmake");

Generator.GenerateTemplate(baseTemplateDir, args[0], args[1]);