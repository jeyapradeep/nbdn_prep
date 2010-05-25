using System;

namespace nothinbutdotnetprep.utility.searching
{
    public class CriteriaFactory<ItemToFilter, PropertyType>
    {
        public Func<ItemToFilter, PropertyType> accessor;
        bool inverse;

        public CriteriaFactory(Func<ItemToFilter, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public CriteriaFactory<ItemToFilter, PropertyType> not
        {
            get
            {
                inverse = inverse ^ true;
                return this;
            }
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value)
        {
            return new PropertyCriteria<ItemToFilter, PropertyType>(accessor,
                                                                    inverse
                                                                        ? (Criteria<PropertyType>) new NotCriteria<PropertyType>(new EqualToCriteria<PropertyType>(value))
                                                                        : new EqualToCriteria<PropertyType>(value));
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] property_values)
        {
            return new PropertyCriteria<ItemToFilter, PropertyType>(accessor,
                                                                   inverse
                                                                       ? (Criteria<PropertyType>) new NotCriteria<PropertyType>(new EqualToAnyCriteria<PropertyType>(property_values))
                                                                       : new EqualToAnyCriteria<PropertyType>(property_values));
        }
    }
}