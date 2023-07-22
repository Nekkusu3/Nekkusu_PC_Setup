// Decompiled with JetBrains decompiler
// Type: Nekkusu_PC_Setup.Program
// Assembly: Nekkusu PC Setup, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5404176C-4BC5-4E75-BF07-CBC8F848C4FF
// Assembly location: D:\User\Documents\server, code etc\Programme\Nekkusu PC Setup.exe

using System;
using System.Windows.Forms;

namespace Nekkusu_PC_Setup
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new Form1());
    }
  }
}
