namespace smab.PlexInfo.Models
{
    public record Subitem
    (
        int? Id,
        string? Filter,
        string Tag
    )
    {
		public override string ToString() => Tag;
    };
}
