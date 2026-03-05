<div align="center">

# 🌡️ Weiss/Votsch Chamber Control System

### Professional Environmental Chamber Management Software
**Built with C# | Real-time Monitoring | Multi-Chamber Support**

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![Language: C#](https://img.shields.io/badge/Language-C%23-239120?logo=csharp)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Status: Active](https://img.shields.io/badge/Status-Active-brightgreen)](https://github.com/TOPTUBBY/CSharpe-WeissControl)

</div>

---

## 📋 Overview

A **robust C# application** for automated control and real-time monitoring of **Weiss/Votsch** environmental testing chambers. This software enables precise temperature and humidity management with comprehensive data logging and multi-chamber support.

### ✨ Key Features

| Feature | Description |
|---------|-------------|
| 🎮 **Real-time Control** | Direct chamber communication with live parameter adjustment |
| 📊 **Data Logging** | Continuous monitoring and recording of all chamber metrics |
| 🔄 **Single & Multi-Chamber** | Flexible implementations for different operational needs |
| 🔗 **Serial Protocol** | Full Weiss/Votsch protocol compliance |
| 💾 **Persistent Storage** | Complete audit trail of all operations |

---

## 📁 Project Structure

```
CSharpe-WeissControl/
├── 🎯 WeissChamberController/          # Single chamber implementation
├── 🔄 WeissChamberController-Multi/    # Multi-chamber orchestration
├── 📖 weiss-votsch_protocol.txt        # Protocol specifications
├── ⚖️  LICENSE                         # MIT License
└── 📘 README.md                        # This file
```

---

## 🚀 Quick Start

### Prerequisites

✅ **.NET Framework** or **.NET Core** (C#)  
✅ **Visual Studio 2019+** or compatible IDE  
✅ **Hardware**: Connected Weiss/Votsch chamber unit  
✅ **Connection**: Serial/COM port or appropriate interface  

### Installation Steps

1️⃣ **Clone the Repository**
```bash
git clone https://github.com/TOPTUBBY/CSharpe-WeissControl.git
cd CSharpe-WeissControl
```

2️⃣ **Open in Visual Studio**
```
File → Open → Project/Solution
Select the .sln file
```

3️⃣ **Review Protocol Documentation**
```
📄 Read: weiss-votsch_protocol.txt
```

4️⃣ **Build & Configure**
```
Build → Build Solution (Ctrl+Shift+B)
Configure chamber parameters
Run the application
```

---

## 💡 Usage

### 🎯 Single Chamber Mode

Use **`WeissChamberController`** when managing a single environmental chamber.

```
✓ Simpler configuration
✓ Lower resource usage
✓ Ideal for individual testing stations
```

### 🔄 Multi-Chamber Mode

Use **`WeissChamberController-Multi`** for controlling multiple chambers simultaneously.

```
✓ Synchronized operation
✓ Centralized monitoring
✓ Batch testing capabilities
✓ Load balancing
```

---

##  Protocol Information

The system communicates with chambers using a **binary serial protocol**:

### Data Flow

```
RECEIVED FROM CHAMBER (RxD)
Temperature | Humidity | Settings | Control Flags | Device ID
    ↓
PROCESSED BY APPLICATION
    ↓
SENT TO CHAMBER (TxD)
Commands | Parameters | Configuration
```

### Supported Chamber Models

| Model | Values | Control Bits |
|-------|--------|--------------|
| V08_VCS_7080_10 | 7 parameters | 32-bit control |
| V26_C7_1000_E | 5 parameters | 32-bit control |
| W27_ESS_C_1000_70_5 | 5 parameters | 32-bit control |
| W28_ESS_C_1300_70_10 | 7 parameters | 32-bit control |
| W29_ESS_T_1700_70_8 | 5 parameters | 32-bit control |

*See `weiss-votsch_protocol.txt` for complete protocol details*

---

## 🎯 Core Components

### 🔧 Control Module
- ⚙️ Chamber parameter management
- 🎚️ Set-point configuration
- ⏱️ Ramp rate control

### 📊 Logging Module
- 📈 Real-time data capture
- 💾 Persistent storage
- 📋 CSV/Log export

### 🔌 Communication Module
- 🔗 Serial protocol implementation
- ⚡ Real-time data streaming
- 🛡️ Error handling & recovery

---

## 📝 Configuration

Each chamber implementation includes configuration files for:

```
🔹 Serial port settings
🔹 Baud rate & communication parameters
🔹 Default set-points
🔹 Logging intervals
🔹 Alarm thresholds
```

---

## 🐛 Troubleshooting

| Issue | Solution |
|-------|----------|
| ❌ No connection | Check COM port, baud rate, cables |
| ❌ Data not logging | Verify write permissions, disk space |
| ❌ Control not responding | Review protocol format, check chamber power |
| ❌ Multi-chamber sync issues | Ensure adequate serial buffer size |

---

## 📄 License

This project is licensed under the **MIT License**  
See [LICENSE](LICENSE) file for complete terms

```
✅ Free for commercial use
✅ Free for private use
✅ Modification allowed
⚠️ Include original license notice
```

---

## 📞 Support & Contribution

### 🐛 Report Issues
[Open an Issue](https://github.com/TOPTUBBY/CSharpe-WeissControl/issues)

### 🤝 Contribute
[Submit a Pull Request](https://github.com/TOPTUBBY/CSharpe-WeissControl/pulls)

### 📧 Contact
For questions or support: [TOPTUBBY](https://github.com/TOPTUBBY)

---

## 📊 Project Status

| Aspect | Status |
|--------|--------|
| Development | 🟢 Active |
| Latest Update | 🕐 March 5, 2026 |
| Stability | 🟢 Stable |
| Production Ready | ✅ Yes |

---

## 🎓 Version History

| Version | Date | Notes |
|---------|------|-------|
| **v2.0.11.2025** | 2026-03-05 | 🎉 Initial Release |
| | | ✨ Single chamber support |
| | | ✨ Multi-chamber orchestration |
| | | ✨ Complete protocol implementation |

---

<div align="center">

### 🚀 Ready to get started?

[📖 Read the Protocol](weiss-votsch_protocol.txt) • [🐛 Report Issue](https://github.com/TOPTUBBY/CSharpe-WeissControl/issues) • [💬 Discussions](https://github.com/TOPTUBBY/CSharpe-WeissControl/discussions)

---

**Made with ❤️ for precise environmental control**

*Last Updated: March 5, 2026 | MIT License © 2026*

</div>
