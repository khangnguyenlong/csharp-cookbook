namespace ObjectComparison
{
    public class DogWithEquality(int id, string name, string furColor) : IEquatable<DogWithEquality>
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public string FurColor { get; set; } = furColor;

        public bool Equals(DogWithEquality other)
        {
            if (other == null) return false;

            return Id == other.Id && Name == other.Name && FurColor == other.FurColor;
        }

        public override bool Equals(object obj) => Equals(obj as DogWithEquality);

        // HashSet, Dictionary, GroupBy, Except, Intersect, Union
        public override int GetHashCode() => HashCode.Combine(Id, Name, FurColor);
    }
}
