namespace nothinbutdotnetprep.utility.searching
{
    public delegate U PropertyAccessor<T, U>(T item);

    public class Where<T>
    {
        public static CriteriaFactory<T, U> has_a<U>(
            PropertyAccessor<T, U> accessor)
        {
            return new CriteriaFactory<T, U>(accessor);
        }
    }
}