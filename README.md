# Unlimited LOB Points & Agent Hiring Mod for Lobotomy Corporation

A lightweight, high-compatibility **BaseMod 5.0** mod for **Lobotomy Corporation** that grants infinite LOB points and removes daily agent hiring limits.

---

## ✨ Features

- **Infinite LOB Points**: Locks your LOB point balance to `999,999` and displays `∞` in the UI.
- **No LOB Deductions**: Customizing or hiring agents never deducts points.
- **Unlimited Daily Hiring Quota**: Removes daily hiring quota limits (`HIRE (0)` ➔ `HIRE (∞)`), allowing you to hire as many agents as you want on any day.
- **High Compatibility**: Uses **Harmony Priority Hooks (`First` / `Last`)** so it works smoothly alongside death penalty / quota mods (such as `Bye_Annoying_Deaths`).
- **Native .NET 4.7.2 Build**: Prevents `ReflectionTypeLoadException` Mono loader errors on Unity Mono runtime.

---

## 📥 Installation

1. Download the latest `UnlimitedLOBPoints.zip` from the [Releases](https://github.com/your-username/UnlimitedLOBPoints/releases) page (or from this repository).
2. Extract the `UnlimitedLOBPoints` folder into your Lobotomy Corporation `BaseMods` directory:
   ```text
   <GameDirectory>\LobotomyCorp_Data\BaseMods\UnlimitedLOBPoints\
   ```
3. Launch **Lobotomy Corporation**.

---

## 🛠️ Building from Source

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download) (or .NET Framework 4.7.2 compiler)
- Lobotomy Corporation installed with BaseMod 5.0

### Build Steps
```bash
dotnet build UnlimitedLOBPoints.csproj -c Release
```

The compiled `UnlimitedLOBPoints.dll` will be output to `bin/Release/net472/`.

---

## 📄 Requirements
- Lobotomy Corporation
- BaseMod 5.0 (or higher)
- 0Harmony.dll (included in BaseMod)

---

## 📜 License
[MIT License](LICENSE)
