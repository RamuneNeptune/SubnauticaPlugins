
using HarmonyLib;
using UnityEngine;


namespace Ramune.FasterScanning
{
    [HarmonyPatch(typeof(PDAScanner), "Scan")]
    public static class Scan_Patch
    {
        public static void Postfix()
        {
            float oldScanTime = 2f;
            float newScanTime = oldScanTime / FasterScanning.config.ScanSpeed;

            if (FasterScanning.config.ScanSpeed > 4)
            {
                newScanTime /= FasterScanning.config.ScanSpeed * 2;
            }

            TechType techType = PDAScanner.scanTarget.techType;
            PDAScanner.EntryData entryData = PDAScanner.GetEntryData(techType);
            //bool flag4 = PDAScanner.complete.Contains(techType);

            if (entryData != null)
            {
                entryData.scanTime = newScanTime;
                ErrorMessage.AddError($"New: {newScanTime}");
            }
            //if (flag4)
            //{
            //    num = newScanTime;
            //    ErrorMessage.AddError($"Known: {newScanTime}");
            //}
            //if (NoCostConsoleCommand.main.fastScanCheat)
            //{
            //    num = newScanTime;
            //    ErrorMessage.AddError($"Fast: {newScanTime}");
            //}

            ErrorMessage.AddError($"<color=#f8cb4f>{PDAScanner.scanTarget.progress}</color>");
        }
    }
}