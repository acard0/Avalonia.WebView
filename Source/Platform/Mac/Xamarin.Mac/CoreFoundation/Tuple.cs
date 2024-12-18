namespace CoreFoundation;

internal static class Tuple
{
	public static Tuple<T1, T2> Create<T1, T2>(T1 item1, T2 item2)
	{
		return new Tuple<T1, T2>(item1, item2);
	}
}
internal class Tuple<T1, T2>
{
	private readonly T1 item1;

	private readonly T2 item2;

	public T1 Item1 => item1;

	public T2 Item2 => item2;

	public Tuple(T1 item1, T2 item2)
	{
		this.item1 = item1;
		this.item2 = item2;
	}
}
