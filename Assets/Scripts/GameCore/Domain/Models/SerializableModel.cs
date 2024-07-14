namespace GameCore.Domain.Models
{
    public abstract class SerializableModel<T> : ISerializable<T>
    {
        public abstract T Serialize();
        public abstract void Deserialize(T dto);
    }
}