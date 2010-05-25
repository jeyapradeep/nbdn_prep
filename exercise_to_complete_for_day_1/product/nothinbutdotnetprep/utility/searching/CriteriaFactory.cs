using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.searching
{
    public class CriteriaFactory<T, U>
    {
        public PropertyAccessor<T, U> accessor;

        public CriteriaFactory(PropertyAccessor<T, U> accessor)
        {
            this.accessor = accessor;
        }

        public Criteria<T> equal_to(U propertyValue)
        {
            return new PredicateCriteria<T>(x => accessor(x).Equals(propertyValue));
        }

        public Criteria<T> not_equal_to(U propertyValue)
        {
            return new PredicateCriteria<T>(x => !accessor(x).Equals(propertyValue));
        }

        public Criteria<T> equal_to_any(params U[] propertyValues)
        {
            return new PredicateCriteria<T>(x =>
            {
                return new List<U>(propertyValues).Contains(accessor(x));
              
            });
        }
    }
}