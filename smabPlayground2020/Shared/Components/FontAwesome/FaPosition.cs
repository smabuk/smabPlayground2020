namespace smabPlayground2020.Shared.Components.FontAwesome;

public record FaPosition {
	public static readonly FaPosition TopLeft = new("top-left");
	public static readonly FaPosition TopRight = new("top-right");
	public static readonly FaPosition BottomLeft = new("bottom-left");
	public static readonly FaPosition BottomRight = new("bottom-right");
	protected string Value { get; private set; }

	protected FaPosition(string value) {
		this.Value = value;
	}

	public override string ToString() {
		return Value;
	}
}
