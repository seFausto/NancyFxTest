using Nancy;
using Nancy.ModelBinding;
using NancyFxTest.DataAccess;
using System;

namespace NancyFxTest
{
    public class RootRoutes : NancyModule
    {

        public RootRoutes()
        {
            Get["/"] = Index;
            Get["jsonTest"] = JsonTest;
            Get["hello/{name}"] = HelloName;

            Post["postTest"] = PostTest;
        }

        private dynamic PostTest(dynamic parameters)
        {
            var person = this.Bind<Person>();

            return string.Format("Hello, {0}. Twitter: {1}. Occupation={2}", person.Name, person.Twitter, person.Occupation);
        }

        private dynamic HelloName(dynamic parameters)
        {
            var name = parameters.name;

            return $"Hello {name}";
        }

        private dynamic Index(dynamic parameters)
        {
            return "Hello World!";
        }

        private dynamic JsonTest(dynamic parameters)
        {
            var test = new
            {
                Name = "Fausto",
                Twitter = "@seFausto",
                Occupation = "Software Developer"
            };

            return Response.AsJson(test);

        }

    }

}
