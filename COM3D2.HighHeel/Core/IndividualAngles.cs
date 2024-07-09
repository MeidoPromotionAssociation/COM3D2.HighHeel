using System;
using System.Runtime.CompilerServices;

namespace COM3D2.HighHeel.Core
{
	// Token: 0x0200000D RID: 13
	public class IndividualAngles
	{
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000055 RID: 85 RVA: 0x00003B95 File Offset: 0x00001D95
		// (set) Token: 0x06000056 RID: 86 RVA: 0x00003B9D File Offset: 0x00001D9D
		public float x { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000057 RID: 87 RVA: 0x00003BA6 File Offset: 0x00001DA6
		// (set) Token: 0x06000058 RID: 88 RVA: 0x00003BAE File Offset: 0x00001DAE
		public float y { get; set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000059 RID: 89 RVA: 0x00003BB7 File Offset: 0x00001DB7
		// (set) Token: 0x0600005A RID: 90 RVA: 0x00003BBF File Offset: 0x00001DBF
		public float z { get; set; }

		// Token: 0x0600005B RID: 91 RVA: 0x00003BC8 File Offset: 0x00001DC8
		[NullableContext(1)]
		public IndividualAngles(float xJson, float yJson, float zJson, string boneName)
		{
			uint num = <PrivateImplementationDetails>.ComputeStringHash(boneName);
			if (num <= 2010127224U)
			{
				if (num <= 1718386694U)
				{
					if (num != 858099551U)
					{
						if (num != 1701609075U)
						{
							if (num != 1718386694U)
							{
								return;
							}
							if (!(boneName == "toeR1"))
							{
								return;
							}
							this.x = xJson + 5.3609614f;
							this.y = yJson + 357.66226f;
							this.z = zJson + 283.45108f;
							return;
						}
						else
						{
							if (!(boneName == "toeR2"))
							{
								return;
							}
							this.x = xJson + 356.4189f;
							this.y = yJson + 1.1177053f;
							this.z = zJson + 286.8531f;
							return;
						}
					}
					else
					{
						if (!(boneName == "toeL11"))
						{
							return;
						}
						this.x = xJson + -6.798167E-05f;
						this.y = yJson + -9.544926E-05f;
						this.z = zJson + 5.9977658E-05f;
						return;
					}
				}
				else if (num != 1735164313U)
				{
					if (num != 1942869653U)
					{
						if (num != 2010127224U)
						{
							return;
						}
						if (!(boneName == "toeR01"))
						{
							return;
						}
						this.x = xJson + 8.0857775E-05f;
						this.y = yJson + 7.6974815E-05f;
						this.z = zJson + 9.406906f;
						return;
					}
					else
					{
						if (!(boneName == "toeR11"))
						{
							return;
						}
						this.x = xJson + -0.00016157667f;
						this.y = yJson + 3.6019292E-06f;
						this.z = zJson + -5.0799536E-05f;
						return;
					}
				}
				else
				{
					if (!(boneName == "toeR0"))
					{
						return;
					}
					this.x = xJson + 0.21639448f;
					this.y = yJson + 359.51022f;
					this.z = zJson + 280.0905f;
					return;
				}
			}
			else if (num <= 3955933670U)
			{
				if (num != 3072892354U)
				{
					if (num != 3274517972U)
					{
						if (num != 3955933670U)
						{
							return;
						}
						if (!(boneName == "toeR21"))
						{
							return;
						}
						this.x = xJson + 7.788669E-05f;
						this.y = yJson + 1.6425354E-05f;
						this.z = zJson + 3.886178f;
						return;
					}
					else
					{
						if (!(boneName == "toeL21"))
						{
							return;
						}
						this.x = xJson + 6.8601395E-05f;
						this.y = yJson + -2.3635866E-05f;
						this.z = zJson + 3.8861122f;
						return;
					}
				}
				else
				{
					if (!(boneName == "toeL01"))
					{
						return;
					}
					this.x = xJson + -0.00015392156f;
					this.y = yJson + 6.99606E-05f;
					this.z = zJson + 9.406873f;
					return;
				}
			}
			else if (num != 4206299828U)
			{
				if (num != 4223077447U)
				{
					if (num != 4256632685U)
					{
						return;
					}
					if (!(boneName == "toeL2"))
					{
						return;
					}
					this.x = xJson + 3.581009f;
					this.y = yJson + 358.88257f;
					this.z = zJson + 286.8532f;
					return;
				}
				else
				{
					if (!(boneName == "toeL0"))
					{
						return;
					}
					this.x = xJson + 359.78348f;
					this.y = yJson + 0.48969793f;
					this.z = zJson + 280.0905f;
					return;
				}
			}
			else
			{
				if (!(boneName == "toeL1"))
				{
					return;
				}
				this.x = xJson + 354.6391f;
				this.y = yJson + 2.3375845f;
				this.z = zJson + 283.45102f;
				return;
			}
		}
	}
}
