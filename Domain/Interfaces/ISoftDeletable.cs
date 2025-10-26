namespace Domain.Interfaces
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; }
        DateTime? DeletedOnUtc { get; }

        void SoftDelete();
        void Restore();
    }
}
