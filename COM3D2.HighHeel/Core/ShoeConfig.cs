using System;

namespace COM3D2.HighHeel.Core
{
	// Token: 0x0200000F RID: 15
	public class ShoeConfig
	{
		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600005E RID: 94 RVA: 0x0000414D File Offset: 0x0000234D
		// (set) Token: 0x0600005F RID: 95 RVA: 0x00004155 File Offset: 0x00002355
		public float BodyOffset { get; set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000060 RID: 96 RVA: 0x0000415E File Offset: 0x0000235E
		// (set) Token: 0x06000061 RID: 97 RVA: 0x00004166 File Offset: 0x00002366
		public float FootLAngle { get; set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000062 RID: 98 RVA: 0x0000416F File Offset: 0x0000236F
		// (set) Token: 0x06000063 RID: 99 RVA: 0x00004177 File Offset: 0x00002377
		public float FootLMax { get; set; } = 55f;

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000064 RID: 100 RVA: 0x00004180 File Offset: 0x00002380
		// (set) Token: 0x06000065 RID: 101 RVA: 0x00004188 File Offset: 0x00002388
		public float ToeLAngle { get; set; } = 280f;

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000066 RID: 102 RVA: 0x00004191 File Offset: 0x00002391
		// (set) Token: 0x06000067 RID: 103 RVA: 0x00004199 File Offset: 0x00002399
		public float ToeL0Angle { get; set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000068 RID: 104 RVA: 0x000041A2 File Offset: 0x000023A2
		// (set) Token: 0x06000069 RID: 105 RVA: 0x000041AA File Offset: 0x000023AA
		public float ToeL01Angle { get; set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600006A RID: 106 RVA: 0x000041B3 File Offset: 0x000023B3
		// (set) Token: 0x0600006B RID: 107 RVA: 0x000041BB File Offset: 0x000023BB
		public float ToeL1Angle { get; set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600006C RID: 108 RVA: 0x000041C4 File Offset: 0x000023C4
		// (set) Token: 0x0600006D RID: 109 RVA: 0x000041CC File Offset: 0x000023CC
		public float ToeL11Angle { get; set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600006E RID: 110 RVA: 0x000041D5 File Offset: 0x000023D5
		// (set) Token: 0x0600006F RID: 111 RVA: 0x000041DD File Offset: 0x000023DD
		public float ToeL2Angle { get; set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000070 RID: 112 RVA: 0x000041E6 File Offset: 0x000023E6
		// (set) Token: 0x06000071 RID: 113 RVA: 0x000041EE File Offset: 0x000023EE
		public float ToeL21Angle { get; set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000072 RID: 114 RVA: 0x000041F7 File Offset: 0x000023F7
		// (set) Token: 0x06000073 RID: 115 RVA: 0x000041FF File Offset: 0x000023FF
		public float ToeL0AngleX { get; set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000074 RID: 116 RVA: 0x00004208 File Offset: 0x00002408
		// (set) Token: 0x06000075 RID: 117 RVA: 0x00004210 File Offset: 0x00002410
		public float ToeL0AngleY { get; set; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000076 RID: 118 RVA: 0x00004219 File Offset: 0x00002419
		// (set) Token: 0x06000077 RID: 119 RVA: 0x00004221 File Offset: 0x00002421
		public float ToeL0AngleZ { get; set; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000078 RID: 120 RVA: 0x0000422A File Offset: 0x0000242A
		// (set) Token: 0x06000079 RID: 121 RVA: 0x00004232 File Offset: 0x00002432
		public float ToeL01AngleX { get; set; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600007A RID: 122 RVA: 0x0000423B File Offset: 0x0000243B
		// (set) Token: 0x0600007B RID: 123 RVA: 0x00004243 File Offset: 0x00002443
		public float ToeL01AngleY { get; set; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600007C RID: 124 RVA: 0x0000424C File Offset: 0x0000244C
		// (set) Token: 0x0600007D RID: 125 RVA: 0x00004254 File Offset: 0x00002454
		public float ToeL01AngleZ { get; set; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600007E RID: 126 RVA: 0x0000425D File Offset: 0x0000245D
		// (set) Token: 0x0600007F RID: 127 RVA: 0x00004265 File Offset: 0x00002465
		public float ToeL1AngleX { get; set; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000080 RID: 128 RVA: 0x0000426E File Offset: 0x0000246E
		// (set) Token: 0x06000081 RID: 129 RVA: 0x00004276 File Offset: 0x00002476
		public float ToeL1AngleY { get; set; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000082 RID: 130 RVA: 0x0000427F File Offset: 0x0000247F
		// (set) Token: 0x06000083 RID: 131 RVA: 0x00004287 File Offset: 0x00002487
		public float ToeL1AngleZ { get; set; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000084 RID: 132 RVA: 0x00004290 File Offset: 0x00002490
		// (set) Token: 0x06000085 RID: 133 RVA: 0x00004298 File Offset: 0x00002498
		public float ToeL11AngleX { get; set; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000086 RID: 134 RVA: 0x000042A1 File Offset: 0x000024A1
		// (set) Token: 0x06000087 RID: 135 RVA: 0x000042A9 File Offset: 0x000024A9
		public float ToeL11AngleY { get; set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000088 RID: 136 RVA: 0x000042B2 File Offset: 0x000024B2
		// (set) Token: 0x06000089 RID: 137 RVA: 0x000042BA File Offset: 0x000024BA
		public float ToeL11AngleZ { get; set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600008A RID: 138 RVA: 0x000042C3 File Offset: 0x000024C3
		// (set) Token: 0x0600008B RID: 139 RVA: 0x000042CB File Offset: 0x000024CB
		public float ToeL2AngleX { get; set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600008C RID: 140 RVA: 0x000042D4 File Offset: 0x000024D4
		// (set) Token: 0x0600008D RID: 141 RVA: 0x000042DC File Offset: 0x000024DC
		public float ToeL2AngleY { get; set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600008E RID: 142 RVA: 0x000042E5 File Offset: 0x000024E5
		// (set) Token: 0x0600008F RID: 143 RVA: 0x000042ED File Offset: 0x000024ED
		public float ToeL2AngleZ { get; set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000090 RID: 144 RVA: 0x000042F6 File Offset: 0x000024F6
		// (set) Token: 0x06000091 RID: 145 RVA: 0x000042FE File Offset: 0x000024FE
		public float ToeL21AngleX { get; set; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000092 RID: 146 RVA: 0x00004307 File Offset: 0x00002507
		// (set) Token: 0x06000093 RID: 147 RVA: 0x0000430F File Offset: 0x0000250F
		public float ToeL21AngleY { get; set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000094 RID: 148 RVA: 0x00004318 File Offset: 0x00002518
		// (set) Token: 0x06000095 RID: 149 RVA: 0x00004320 File Offset: 0x00002520
		public float ToeL21AngleZ { get; set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000096 RID: 150 RVA: 0x00004329 File Offset: 0x00002529
		// (set) Token: 0x06000097 RID: 151 RVA: 0x00004331 File Offset: 0x00002531
		public float FootRAngle { get; set; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000098 RID: 152 RVA: 0x0000433A File Offset: 0x0000253A
		// (set) Token: 0x06000099 RID: 153 RVA: 0x00004342 File Offset: 0x00002542
		public float FootRMax { get; set; } = 55f;

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600009A RID: 154 RVA: 0x0000434B File Offset: 0x0000254B
		// (set) Token: 0x0600009B RID: 155 RVA: 0x00004353 File Offset: 0x00002553
		public float ToeRAngle { get; set; } = 280f;

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600009C RID: 156 RVA: 0x0000435C File Offset: 0x0000255C
		// (set) Token: 0x0600009D RID: 157 RVA: 0x00004364 File Offset: 0x00002564
		public float ToeR0Angle { get; set; }

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x0600009E RID: 158 RVA: 0x0000436D File Offset: 0x0000256D
		// (set) Token: 0x0600009F RID: 159 RVA: 0x00004375 File Offset: 0x00002575
		public float ToeR01Angle { get; set; }

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x0000437E File Offset: 0x0000257E
		// (set) Token: 0x060000A1 RID: 161 RVA: 0x00004386 File Offset: 0x00002586
		public float ToeR1Angle { get; set; }

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000A2 RID: 162 RVA: 0x0000438F File Offset: 0x0000258F
		// (set) Token: 0x060000A3 RID: 163 RVA: 0x00004397 File Offset: 0x00002597
		public float ToeR11Angle { get; set; }

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000A4 RID: 164 RVA: 0x000043A0 File Offset: 0x000025A0
		// (set) Token: 0x060000A5 RID: 165 RVA: 0x000043A8 File Offset: 0x000025A8
		public float ToeR2Angle { get; set; }

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000A6 RID: 166 RVA: 0x000043B1 File Offset: 0x000025B1
		// (set) Token: 0x060000A7 RID: 167 RVA: 0x000043B9 File Offset: 0x000025B9
		public float ToeR21Angle { get; set; }

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000A8 RID: 168 RVA: 0x000043C2 File Offset: 0x000025C2
		// (set) Token: 0x060000A9 RID: 169 RVA: 0x000043CA File Offset: 0x000025CA
		public float ToeR0AngleX { get; set; }

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060000AA RID: 170 RVA: 0x000043D3 File Offset: 0x000025D3
		// (set) Token: 0x060000AB RID: 171 RVA: 0x000043DB File Offset: 0x000025DB
		public float ToeR0AngleY { get; set; }

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060000AC RID: 172 RVA: 0x000043E4 File Offset: 0x000025E4
		// (set) Token: 0x060000AD RID: 173 RVA: 0x000043EC File Offset: 0x000025EC
		public float ToeR0AngleZ { get; set; }

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060000AE RID: 174 RVA: 0x000043F5 File Offset: 0x000025F5
		// (set) Token: 0x060000AF RID: 175 RVA: 0x000043FD File Offset: 0x000025FD
		public float ToeR01AngleX { get; set; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x00004406 File Offset: 0x00002606
		// (set) Token: 0x060000B1 RID: 177 RVA: 0x0000440E File Offset: 0x0000260E
		public float ToeR01AngleY { get; set; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060000B2 RID: 178 RVA: 0x00004417 File Offset: 0x00002617
		// (set) Token: 0x060000B3 RID: 179 RVA: 0x0000441F File Offset: 0x0000261F
		public float ToeR01AngleZ { get; set; }

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060000B4 RID: 180 RVA: 0x00004428 File Offset: 0x00002628
		// (set) Token: 0x060000B5 RID: 181 RVA: 0x00004430 File Offset: 0x00002630
		public float ToeR1AngleX { get; set; }

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000B6 RID: 182 RVA: 0x00004439 File Offset: 0x00002639
		// (set) Token: 0x060000B7 RID: 183 RVA: 0x00004441 File Offset: 0x00002641
		public float ToeR1AngleY { get; set; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000B8 RID: 184 RVA: 0x0000444A File Offset: 0x0000264A
		// (set) Token: 0x060000B9 RID: 185 RVA: 0x00004452 File Offset: 0x00002652
		public float ToeR1AngleZ { get; set; }

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000BA RID: 186 RVA: 0x0000445B File Offset: 0x0000265B
		// (set) Token: 0x060000BB RID: 187 RVA: 0x00004463 File Offset: 0x00002663
		public float ToeR11AngleX { get; set; }

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000BC RID: 188 RVA: 0x0000446C File Offset: 0x0000266C
		// (set) Token: 0x060000BD RID: 189 RVA: 0x00004474 File Offset: 0x00002674
		public float ToeR11AngleY { get; set; }

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000BE RID: 190 RVA: 0x0000447D File Offset: 0x0000267D
		// (set) Token: 0x060000BF RID: 191 RVA: 0x00004485 File Offset: 0x00002685
		public float ToeR11AngleZ { get; set; }

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x0000448E File Offset: 0x0000268E
		// (set) Token: 0x060000C1 RID: 193 RVA: 0x00004496 File Offset: 0x00002696
		public float ToeR2AngleX { get; set; }

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000C2 RID: 194 RVA: 0x0000449F File Offset: 0x0000269F
		// (set) Token: 0x060000C3 RID: 195 RVA: 0x000044A7 File Offset: 0x000026A7
		public float ToeR2AngleY { get; set; }

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000C4 RID: 196 RVA: 0x000044B0 File Offset: 0x000026B0
		// (set) Token: 0x060000C5 RID: 197 RVA: 0x000044B8 File Offset: 0x000026B8
		public float ToeR2AngleZ { get; set; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000C6 RID: 198 RVA: 0x000044C1 File Offset: 0x000026C1
		// (set) Token: 0x060000C7 RID: 199 RVA: 0x000044C9 File Offset: 0x000026C9
		public float ToeR21AngleX { get; set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000C8 RID: 200 RVA: 0x000044D2 File Offset: 0x000026D2
		// (set) Token: 0x060000C9 RID: 201 RVA: 0x000044DA File Offset: 0x000026DA
		public float ToeR21AngleY { get; set; }

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000CA RID: 202 RVA: 0x000044E3 File Offset: 0x000026E3
		// (set) Token: 0x060000CB RID: 203 RVA: 0x000044EB File Offset: 0x000026EB
		public float ToeR21AngleZ { get; set; }

		// Token: 0x060000CC RID: 204 RVA: 0x000044F4 File Offset: 0x000026F4
		public void Deconstruct(out float bodyOffset, out float footLAngle, out float footLMax, out float toeLAngle, out float toeL0Angle, out float toeL01Angle, out float toeL1Angle, out float toeL11Angle, out float toeL2Angle, out float toeL21Angle, out float toeL0AngleX, out float toeL01AngleX, out float toeL1AngleX, out float toeL11AngleX, out float toeL2AngleX, out float toeL21AngleX, out float toeL0AngleY, out float toeL01AngleY, out float toeL1AngleY, out float toeL11AngleY, out float toeL2AngleY, out float toeL21AngleY, out float toeL0AngleZ, out float toeL01AngleZ, out float toeL1AngleZ, out float toeL11AngleZ, out float toeL2AngleZ, out float toeL21AngleZ, out float footRAngle, out float footRMax, out float toeRAngle, out float toeR0Angle, out float toeR01Angle, out float toeR1Angle, out float toeR11Angle, out float toeR2Angle, out float toeR21Angle, out float toeR0AngleX, out float toeR01AngleX, out float toeR1AngleX, out float toeR11AngleX, out float toeR2AngleX, out float toeR21AngleX, out float toeR0AngleY, out float toeR01AngleY, out float toeR1AngleY, out float toeR11AngleY, out float toeR2AngleY, out float toeR21AngleY, out float toeR0AngleZ, out float toeR01AngleZ, out float toeR1AngleZ, out float toeR11AngleZ, out float toeR2AngleZ, out float toeR21AngleZ)
		{
			bodyOffset = this.BodyOffset;
			footLAngle = this.FootLAngle;
			footLMax = this.FootLMax;
			toeLAngle = this.ToeLAngle;
			toeL0Angle = this.ToeL0Angle;
			toeL01Angle = this.ToeL01Angle;
			toeL1Angle = this.ToeL1Angle;
			toeL11Angle = this.ToeL11Angle;
			toeL2Angle = this.ToeL2Angle;
			toeL21Angle = this.ToeL21Angle;
			toeL0AngleX = this.ToeL0AngleX;
			toeL0AngleY = this.ToeL0AngleY;
			toeL0AngleZ = this.ToeL0AngleZ;
			toeL01AngleX = this.ToeL01AngleX;
			toeL01AngleY = this.ToeL01AngleY;
			toeL01AngleZ = this.ToeL01AngleZ;
			toeL1AngleX = this.ToeL1AngleX;
			toeL1AngleY = this.ToeL1AngleY;
			toeL1AngleZ = this.ToeL1AngleZ;
			toeL11AngleX = this.ToeL11AngleX;
			toeL11AngleY = this.ToeL11AngleY;
			toeL11AngleZ = this.ToeL11AngleZ;
			toeL2AngleX = this.ToeL2AngleX;
			toeL2AngleY = this.ToeL2AngleY;
			toeL2AngleZ = this.ToeL2AngleZ;
			toeL21AngleX = this.ToeL21AngleX;
			toeL21AngleY = this.ToeL21AngleY;
			toeL21AngleZ = this.ToeL21AngleZ;
			footRAngle = this.FootRAngle;
			footRMax = this.FootRMax;
			toeRAngle = this.ToeRAngle;
			toeR0Angle = this.ToeR0Angle;
			toeR01Angle = this.ToeR01Angle;
			toeR1Angle = this.ToeR1Angle;
			toeR11Angle = this.ToeR11Angle;
			toeR2Angle = this.ToeR2Angle;
			toeR21Angle = this.ToeR21Angle;
			toeR0AngleX = this.ToeR0AngleX;
			toeR0AngleY = this.ToeR0AngleY;
			toeR0AngleZ = this.ToeR0AngleZ;
			toeR01AngleX = this.ToeR01AngleX;
			toeR01AngleY = this.ToeR01AngleY;
			toeR01AngleZ = this.ToeR01AngleZ;
			toeR1AngleX = this.ToeR1AngleX;
			toeR1AngleY = this.ToeR1AngleY;
			toeR1AngleZ = this.ToeR1AngleZ;
			toeR11AngleX = this.ToeR11AngleX;
			toeR11AngleY = this.ToeR11AngleY;
			toeR11AngleZ = this.ToeR11AngleZ;
			toeR2AngleX = this.ToeR2AngleX;
			toeR2AngleY = this.ToeR2AngleY;
			toeR2AngleZ = this.ToeR2AngleZ;
			toeR21AngleX = this.ToeR21AngleX;
			toeR21AngleY = this.ToeR21AngleY;
			toeR21AngleZ = this.ToeR21AngleZ;
		}

		// Token: 0x02000014 RID: 20
		public enum ShoeConfigParameter
		{
			// Token: 0x04000080 RID: 128
			BodyOffset,
			// Token: 0x04000081 RID: 129
			FootLAngle,
			// Token: 0x04000082 RID: 130
			FootLMax,
			// Token: 0x04000083 RID: 131
			ToeLAngle,
			// Token: 0x04000084 RID: 132
			ToeL0Angle,
			// Token: 0x04000085 RID: 133
			ToeL01Angle,
			// Token: 0x04000086 RID: 134
			ToeL1Angle,
			// Token: 0x04000087 RID: 135
			ToeL11Angle,
			// Token: 0x04000088 RID: 136
			ToeL2Angle,
			// Token: 0x04000089 RID: 137
			ToeL21Angle,
			// Token: 0x0400008A RID: 138
			ToeL0AngleX,
			// Token: 0x0400008B RID: 139
			ToeL01AngleX,
			// Token: 0x0400008C RID: 140
			ToeL1AngleX,
			// Token: 0x0400008D RID: 141
			ToeL11AngleX,
			// Token: 0x0400008E RID: 142
			ToeL2AngleX,
			// Token: 0x0400008F RID: 143
			ToeL21AngleX,
			// Token: 0x04000090 RID: 144
			ToeL0AngleY,
			// Token: 0x04000091 RID: 145
			ToeL01AngleY,
			// Token: 0x04000092 RID: 146
			ToeL1AngleY,
			// Token: 0x04000093 RID: 147
			ToeL11AngleY,
			// Token: 0x04000094 RID: 148
			ToeL2AngleY,
			// Token: 0x04000095 RID: 149
			ToeL21AngleY,
			// Token: 0x04000096 RID: 150
			ToeL0AngleZ,
			// Token: 0x04000097 RID: 151
			ToeL01AngleZ,
			// Token: 0x04000098 RID: 152
			ToeL1AngleZ,
			// Token: 0x04000099 RID: 153
			ToeL11AngleZ,
			// Token: 0x0400009A RID: 154
			ToeL2AngleZ,
			// Token: 0x0400009B RID: 155
			ToeL21AngleZ,
			// Token: 0x0400009C RID: 156
			FootRAngle,
			// Token: 0x0400009D RID: 157
			FootRMax,
			// Token: 0x0400009E RID: 158
			ToeRAngle,
			// Token: 0x0400009F RID: 159
			ToeR0Angle,
			// Token: 0x040000A0 RID: 160
			ToeR01Angle,
			// Token: 0x040000A1 RID: 161
			ToeR1Angle,
			// Token: 0x040000A2 RID: 162
			ToeR11Angle,
			// Token: 0x040000A3 RID: 163
			ToeR2Angle,
			// Token: 0x040000A4 RID: 164
			ToeR21Angle,
			// Token: 0x040000A5 RID: 165
			ToeR0AngleX,
			// Token: 0x040000A6 RID: 166
			ToeR01AngleX,
			// Token: 0x040000A7 RID: 167
			ToeR1AngleX,
			// Token: 0x040000A8 RID: 168
			ToeR11AngleX,
			// Token: 0x040000A9 RID: 169
			ToeR2AngleX,
			// Token: 0x040000AA RID: 170
			ToeR21AngleX,
			// Token: 0x040000AB RID: 171
			ToeR0AngleY,
			// Token: 0x040000AC RID: 172
			ToeR01AngleY,
			// Token: 0x040000AD RID: 173
			ToeR1AngleY,
			// Token: 0x040000AE RID: 174
			ToeR11AngleY,
			// Token: 0x040000AF RID: 175
			ToeR2AngleY,
			// Token: 0x040000B0 RID: 176
			ToeR21AngleY,
			// Token: 0x040000B1 RID: 177
			ToeR0AngleZ,
			// Token: 0x040000B2 RID: 178
			ToeR01AngleZ,
			// Token: 0x040000B3 RID: 179
			ToeR1AngleZ,
			// Token: 0x040000B4 RID: 180
			ToeR11AngleZ,
			// Token: 0x040000B5 RID: 181
			ToeR2AngleZ,
			// Token: 0x040000B6 RID: 182
			ToeR21AngleZ
		}
	}
}
