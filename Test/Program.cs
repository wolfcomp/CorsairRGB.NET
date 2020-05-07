using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CorsairRGB.NET;

namespace Test
{

    public class EventPrinter
    {
        public void print(CorsairEvent e)
        {
            Console.Write("Event #");
            Console.Write(Convert.ToString(++m_eventCounter));
            Console.Write("\n");
            if (e.id == CorsairEventId.CEI_DeviceConnectionStatusChangedEvent)
            {
                printConnectionEvent(e.deviceConnectionStatusChangedEvent);
            }
            else if (e.id == CorsairEventId.CEI_KeyEvent)
            {
                printKeyEvent(e.keyEvent);
            }
            else
            {
                Console.Write("Invalid event!");
                Console.Write("\n");
            }
        }

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: void printConnectionEvent(const CorsairDeviceConnectionStatusChangedEvent *e) const
        private void printConnectionEvent(CorsairDeviceConnectionStatusChangedEvent e)
        {
            Console.Write("Device id: ");
            Console.Write(e.deviceId);
            Console.Write("   Status: ");
            Console.Write((e.isConnected ? "connected" : "disconnected"));
            Console.Write("\n");

        }

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: void printKeyEvent(const CorsairKeyEvent *e) const
        private void printKeyEvent(CorsairKeyEvent e)
        {
            Console.Write(" Device id: ");
            Console.Write(e.deviceId);
            Console.Write("    Key id: ");
            Console.Write(e.keyId);
            Console.Write(" Key state: ");
            Console.Write((e.isPressed ? "pressed" : "released"));
            Console.Write("\n");
        }

        private int m_eventCounter = 0;

        public static readonly Dictionary<CorsairKeyId, string> keyIdStrings = new Dictionary<CorsairKeyId, string>()
        {
            {CorsairKeyId.CorsairKey_Invalid, "CorsairKey_Invalid"},
            {CorsairKeyId.CorsairKeyKb_G1, "CorsairKeyKb_G1"},
            {CorsairKeyId.CorsairKeyKb_G2, "CorsairKeyKb_G2"},
            {CorsairKeyId.CorsairKeyKb_G3, "CorsairKeyKb_G3"},
            {CorsairKeyId.CorsairKeyKb_G4, "CorsairKeyKb_G4"},
            {CorsairKeyId.CorsairKeyKb_G5, "CorsairKeyKb_G5"},
            {CorsairKeyId.CorsairKeyKb_G6, "CorsairKeyKb_G6"},
            {CorsairKeyId.CorsairKeyKb_G7, "CorsairKeyKb_G7"},
            {CorsairKeyId.CorsairKeyKb_G8, "CorsairKeyKb_G8"},
            {CorsairKeyId.CorsairKeyKb_G9, "CorsairKeyKb_G9"},
            {CorsairKeyId.CorsairKeyKb_G10, "CorsairKeyKb_G10"},
            {CorsairKeyId.CorsairKeyKb_G11, "CorsairKeyKb_G11"},
            {CorsairKeyId.CorsairKeyKb_G12, "CorsairKeyKb_G12"},
            {CorsairKeyId.CorsairKeyKb_G13, "CorsairKeyKb_G13"},
            {CorsairKeyId.CorsairKeyKb_G14, "CorsairKeyKb_G14"},
            {CorsairKeyId.CorsairKeyKb_G15, "CorsairKeyKb_G15"},
            {CorsairKeyId.CorsairKeyKb_G16, "CorsairKeyKb_G16"},
            {CorsairKeyId.CorsairKeyKb_G17, "CorsairKeyKb_G17"},
            {CorsairKeyId.CorsairKeyKb_G18, "CorsairKeyKb_G18"},
            {CorsairKeyId.CorsairKeyMouse_M1, "CorsairKeyMouse_M1"},
            {CorsairKeyId.CorsairKeyMouse_M2, "CorsairKeyMouse_M2"},
            {CorsairKeyId.CorsairKeyMouse_M3, "CorsairKeyMouse_M3"},
            {CorsairKeyId.CorsairKeyMouse_M4, "CorsairKeyMouse_M4"},
            {CorsairKeyId.CorsairKeyMouse_M5, "CorsairKeyMouse_M5"},
            {CorsairKeyId.CorsairKeyMouse_M6, "CorsairKeyMouse_M6"},
            {CorsairKeyId.CorsairKeyMouse_M7, "CorsairKeyMouse_M7"},
            {CorsairKeyId.CorsairKeyMouse_M8, "CorsairKeyMouse_M8"},
            {CorsairKeyId.CorsairKeyMouse_M9, "CorsairKeyMouse_M9"},
            {CorsairKeyId.CorsairKeyMouse_M10, "CorsairKeyMouse_M10"},
            {CorsairKeyId.CorsairKeyMouse_M11, "CorsairKeyMouse_M11"},
            {CorsairKeyId.CorsairKeyMouse_M12, "CorsairKeyMouse_M12"}
        };

    }


    class Program
    {
        static void Main(string[] args)
        {

            var dets = CUE.PerformProtocolHandshake();

            var intPtr = new IntPtr();
            CUE.Subscribe(OnEvent, intPtr);

            if (CUE.RequestControl())
            {
                int a = CUE.GetDeviceCount();
                List<CorsairDeviceInfo> infos = new List<CorsairDeviceInfo>();
                for (int i = 0; i < a; i++)
                {
                    var info = CUE.GetDeviceInfo(i);
                    Console.WriteLine(info.Model);
                    infos.Add(info);
                }

                var colorbuffer = new CorsairLedColor[]
                {
                    new CorsairLedColor()
                    {
                        LedId = CorsairLedId.K_W,
                        R = 0,
                        G = 0,
                        B = 255
                    },
                    new CorsairLedColor()
                    {
                        LedId = CorsairLedId.K_A,
                        R = 0,
                        G = 0,
                        B = 255
                    },
                    new CorsairLedColor()
                    {
                        LedId = CorsairLedId.K_S,
                        R = 0,
                        G = 0,
                        B = 255
                    },
                    new CorsairLedColor()
                    {
                        LedId = CorsairLedId.K_D,
                        R = 0,
                        G = 0,
                        B = 255
                    },
                    new CorsairLedColor()
                    {
                        LedId = CorsairLedId.M_1,
                        R = 0,
                        G = 0,
                        B = 255
                    },
                    new CorsairLedColor()
                    {
                        LedId = CorsairLedId.M_2,
                        R = 0,
                        G = 0,
                        B = 255
                    },
                    new CorsairLedColor()
                    {
                        LedId = CorsairLedId.M_3,
                        R = 0,
                        G = 0,
                        B = 255
                    },
                    new CorsairLedColor()
                    {
                        LedId = CorsairLedId.M_4,
                        R = 0,
                        G = 0,
                        B = 255
                    },
                    new CorsairLedColor()
                    {
                        LedId = CorsairLedId.M_5,
                        R = 0,
                        G = 0,
                        B = 255
                    },
                    new CorsairLedColor()
                    {
                        LedId = CorsairLedId.M_6,
                        R = 0,
                        G = 0,
                        B = 255
                    },
                };
                CUE.SetLedColors(colorbuffer);
                CUE.Update();
            }

            Console.ReadLine();
            CUE.ReleaseControl();
            while (Console.ReadKey().Key != ConsoleKey.Q)
            {

            }
            CUE.Unsubscribe();
        }

        private static void OnEvent(IntPtr obj, CorsairEvent corsairevent)
        {
            new EventPrinter().print(corsairevent);
        }
    }
}
