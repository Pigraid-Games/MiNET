namespace MiNET.Worlds.Anvil.Mapping
{
	public class BitPropertyStateMapper : PropertyStateMapper
	{
		public BitPropertyStateMapper(string oldName)
			: base(oldName, $"{oldName}_bit",
				  new PropertyValueStateMapper("false", "0"),
				  new PropertyValueStateMapper("true", "1"))
		{

		}
	}
}
