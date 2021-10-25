namespace smabPlayground2020.Shared.Components.FontAwesome;

public record FaType {
	public static readonly FaType FontAwesome5Solid = new("fas");
	public static readonly FaType FontAwesome5Regular = new("far");
	public static readonly FaType FontAwesome5Light = new("fal");
	public static readonly FaType FontAwesome5DuoTone = new("fad");
	public static readonly FaType FontAwesome5Thin = new("fat");
	public static readonly FaType FontAwesome5Brands = new("fab");
	public static readonly FaType Solid = new("fa-solid");
	public static readonly FaType Regular = new("fa-regular");
	public static readonly FaType Light = new("fa-light");
	public static readonly FaType DuoTone = new("fa-duotone");
	public static readonly FaType Thin = new("fa-thin");
	public static readonly FaType Brands = new("fa-brands");
	protected string Value { get; private set; }

	protected FaType(string value) {
		this.Value = value;
	}

	public override string ToString() {
		return Value;
	}

	public bool Version5OrLEarlier => !Version6OrLater;
	public bool Version6OrLater => Value.Contains('-');

}
