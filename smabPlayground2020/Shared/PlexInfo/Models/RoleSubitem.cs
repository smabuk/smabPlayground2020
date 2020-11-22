namespace smab.PlexInfo.Models
{
	public record RoleSubitem 
    (
        string? Role,
        string? Thumb,
        int? Id,
        string? Filter,
        string Tag

    ) : Subitem(Id, Filter, Tag);
}
