namespace Domain.Utils
{
    public static class IdGenerator
    {   

        static IdGenerator()
        {
        }

        public static int GetNextId(List<Object> memoryEntities)
        {

            int nextId = 0;

            nextId = memoryEntities.Count > 0 ? memoryEntities.Max(e => (int)e.GetType().GetProperty("Id").GetValue(e)) + 1 : 1;

            return nextId;
        }


    }
}
