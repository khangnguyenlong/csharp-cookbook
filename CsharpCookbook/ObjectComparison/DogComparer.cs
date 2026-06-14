namespace ObjectComparison
{
    public class DogComparer : IEqualityComparer<Dog>
    {
        public bool Equals(Dog x, Dog y)
        {
            return x.Id == y.Id && x.Name == y.Name && x.FurColor == y.FurColor;
        }

        public int GetHashCode(Dog obj) => HashCode.Combine(obj.Id, obj.Name, obj.FurColor);
    }
}
