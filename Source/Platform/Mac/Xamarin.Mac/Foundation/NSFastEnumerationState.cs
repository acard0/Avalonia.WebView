namespace Foundation;
internal struct NSFastEnumerationState
{
    private readonly nint state;

    internal IntPtr itemsPtr;

    internal IntPtr mutationsPtr;

    private readonly nint extra1;

    private readonly nint extra2;

    private readonly nint extra3;

    private readonly nint extra4;

    private readonly nint extra5;
}
