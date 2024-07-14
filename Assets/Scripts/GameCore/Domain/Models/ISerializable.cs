namespace GameCore.Domain.Models
{
    public interface ISerializable<T>
    {
        T Serialize();
        void Deserialize(T dto);
    }
}