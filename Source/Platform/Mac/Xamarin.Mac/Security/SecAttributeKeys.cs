using Foundation;
using ObjCRuntime;

namespace Security;

internal static class SecAttributeKeys
{
	[BindingImpl(BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
	private static NSString? _AccessControlKey;

	[BindingImpl(BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
	private static NSString? _ApplicationTagKey;

	[BindingImpl(BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
	private static NSString? _CanDecryptKey;

	[BindingImpl(BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
	private static NSString? _CanDeriveKey;

	[BindingImpl(BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
	private static NSString? _CanEncryptKey;

	[BindingImpl(BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
	private static NSString? _CanSignKey;

	[BindingImpl(BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
	private static NSString? _CanUnwrapKey;

	[BindingImpl(BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
	private static NSString? _CanVerifyKey;

	[BindingImpl(BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
	private static NSString? _EffectiveKeySizeKey;

	[BindingImpl(BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
	private static NSString? _IsPermanentKey;

	[BindingImpl(BindingImplOptions.GeneratedCode | BindingImplOptions.Optimizable)]
	private static NSString? _LabelKey;

	[Field("kSecAttrAccessControl", "Security")]
	[Introduced(PlatformName.iOS, 8, 0, PlatformArchitecture.All, null)]
	[Introduced(PlatformName.MacOSX, 10, 10, PlatformArchitecture.All, null)]
	public static NSString AccessControlKey
	{
		[Introduced(PlatformName.iOS, 8, 0, PlatformArchitecture.All, null)]
		[Introduced(PlatformName.MacOSX, 10, 10, PlatformArchitecture.All, null)]
		get
		{
			if (_AccessControlKey == null)
			{
				_AccessControlKey = Dlfcn.GetStringConstant(Libraries.Security.Handle, "kSecAttrAccessControl");
			}
			return _AccessControlKey;
		}
	}

	[Field("kSecAttrApplicationTag", "Security")]
	public static NSString ApplicationTagKey
	{
		get
		{
			if (_ApplicationTagKey == null)
			{
				_ApplicationTagKey = Dlfcn.GetStringConstant(Libraries.Security.Handle, "kSecAttrApplicationTag");
			}
			return _ApplicationTagKey;
		}
	}

	[Field("kSecAttrCanDecrypt", "Security")]
	public static NSString CanDecryptKey
	{
		get
		{
			if (_CanDecryptKey == null)
			{
				_CanDecryptKey = Dlfcn.GetStringConstant(Libraries.Security.Handle, "kSecAttrCanDecrypt");
			}
			return _CanDecryptKey;
		}
	}

	[Field("kSecAttrCanDerive", "Security")]
	public static NSString CanDeriveKey
	{
		get
		{
			if (_CanDeriveKey == null)
			{
				_CanDeriveKey = Dlfcn.GetStringConstant(Libraries.Security.Handle, "kSecAttrCanDerive");
			}
			return _CanDeriveKey;
		}
	}

	[Field("kSecAttrCanEncrypt", "Security")]
	public static NSString CanEncryptKey
	{
		get
		{
			if (_CanEncryptKey == null)
			{
				_CanEncryptKey = Dlfcn.GetStringConstant(Libraries.Security.Handle, "kSecAttrCanEncrypt");
			}
			return _CanEncryptKey;
		}
	}

	[Field("kSecAttrCanSign", "Security")]
	public static NSString CanSignKey
	{
		get
		{
			if (_CanSignKey == null)
			{
				_CanSignKey = Dlfcn.GetStringConstant(Libraries.Security.Handle, "kSecAttrCanSign");
			}
			return _CanSignKey;
		}
	}

	[Field("kSecAttrCanUnwrap", "Security")]
	public static NSString CanUnwrapKey
	{
		get
		{
			if (_CanUnwrapKey == null)
			{
				_CanUnwrapKey = Dlfcn.GetStringConstant(Libraries.Security.Handle, "kSecAttrCanUnwrap");
			}
			return _CanUnwrapKey;
		}
	}

	[Field("kSecAttrCanVerify", "Security")]
	public static NSString CanVerifyKey
	{
		get
		{
			if (_CanVerifyKey == null)
			{
				_CanVerifyKey = Dlfcn.GetStringConstant(Libraries.Security.Handle, "kSecAttrCanVerify");
			}
			return _CanVerifyKey;
		}
	}

	[Field("kSecAttrEffectiveKeySize", "Security")]
	public static NSString EffectiveKeySizeKey
	{
		get
		{
			if (_EffectiveKeySizeKey == null)
			{
				_EffectiveKeySizeKey = Dlfcn.GetStringConstant(Libraries.Security.Handle, "kSecAttrEffectiveKeySize");
			}
			return _EffectiveKeySizeKey;
		}
	}

	[Field("kSecAttrIsPermanent", "Security")]
	public static NSString IsPermanentKey
	{
		get
		{
			if (_IsPermanentKey == null)
			{
				_IsPermanentKey = Dlfcn.GetStringConstant(Libraries.Security.Handle, "kSecAttrIsPermanent");
			}
			return _IsPermanentKey;
		}
	}

	[Field("kSecAttrLabel", "Security")]
	public static NSString LabelKey
	{
		get
		{
			if (_LabelKey == null)
			{
				_LabelKey = Dlfcn.GetStringConstant(Libraries.Security.Handle, "kSecAttrLabel");
			}
			return _LabelKey;
		}
	}
}