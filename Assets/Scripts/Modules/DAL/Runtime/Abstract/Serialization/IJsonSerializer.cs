namespace Modules.DAL.Runtime.Abstract.Serialization
{
    public interface IJsonSerializer
    {
        string Serialize(object @object);
        T Deserialize<T>(string jsonString);
    }
}