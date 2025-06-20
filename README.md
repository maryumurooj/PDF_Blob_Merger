﻿
# 📄 PDF Merger by Company (Local Blob Simulation)

This is a simple .NET Core Web API project that simulates merging PDF files stored in subfolders (per company). Each subfolder inside the `wwwroot/pdfs/` directory represents a company, and all PDFs inside each company folder are merged into a single file and stored in `wwwroot/merged/`.

---

## ✅ Features

- Reads multiple subfolders representing different companies
- Merges all PDFs inside each company folder
- Saves merged output to a public folder (`merged/`)
- Returns downloadable URLs for each merged file
- No frontend needed (but can be added easily)

---

## 📁 Folder Structure

```

wwwroot/
├── pdfs/
│   ├── CompanyA/
│   │   ├── doc1.pdf
│   │   └── doc2.pdf
│   └── CompanyB/
│       └── report1.pdf
└── merged/
└── CompanyA\_merged.pdf

```

---

## 🚀 How to Run

### 1. Clone the repo

```bash
git clone https://github.com/yourusername/pdf-merge-company.git
cd pdf-merge-company
```

### 2. Install dependencies

```bash
dotnet add package PdfSharpCore
```

### 3. Run the API

```bash
dotnet run
```

Server will start at:

```
http://localhost:xxxx (check it in the terminal)
```

---

## 🔁 Trigger the Merge

Use this `curl` command:

```bash
curl -X POST http://localhost:xxxx/api/pdfblobmerge/merge-all-companies
```

### ✅ Response

```json
[
  {
    "company": "CompanyA",
    "file": "CompanyA_merged.pdf",
    "url": "http://localhost:xxxx/merged/CompanyA_merged.pdf"
  }
]
```

---

## 🛠 Tech Stack

* .NET 8 Web API
* PdfSharpCore for PDF processing
* Local file system for simulating blob storage

---

## 📦 Future 

* Connect to Azure Blob Storage instead of local folders


---



