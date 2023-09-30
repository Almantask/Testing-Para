using AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Source.Tests
{
    public static class Dummy
    {
        private static readonly Fixture _fixture = new Fixture();

        public static T Any<T>() => _fixture.Create<T>();
    }
}
