using System.Collections.Generic;
using System.Linq;
using Xunit.Sdk;

namespace WebApiPractice.Tests.Attributes {
    internal class RangeDataAttribute : DataAttribute {
        private readonly int _count;
        private readonly int _start;

        public RangeDataAttribute( int start, int count ) {
            _start = start;
            _count = count;
        }

        public override IEnumerable<object[]> GetData( System.Reflection.MethodInfo testMethod ) {
            return Enumerable.Range( _start, _count ).Select( x => new object[] { x } );
        }
    }
}
