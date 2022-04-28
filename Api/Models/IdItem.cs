namespace RotmgNetworkingLib.Api.Models
{
    public class IdItem
    {
        public long? Id;
        public int Type;

        public IdItem() { }

        public IdItem(long? id, int type)
        {
            Id = id;
            Type = type;
        }

        public static IdItem Parse(string str)
        {
            IdItem result = new IdItem();

            if (str == null)
                return result;

            int split = str.IndexOf('#');

            if (split == -1)
                result.Type = int.Parse(str);
            else
            {
                result.Type = int.Parse(str.Substring(0, split));
                result.Id = long.Parse(str.Substring(split + 1));
            }

            return result;
        }
    }
}
