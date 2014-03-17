using Fixie.Conventions;

namespace FixieExample
{
    public class SeleniumTestConvention : Convention
    {
        public SeleniumTestConvention()
        {
            Classes.Where(t => t.Name.StartsWith("When"));

            Methods.Where(method => method.Name.StartsWith("Should"));
        }
    }
}