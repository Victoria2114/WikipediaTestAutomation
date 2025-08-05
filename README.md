# 🧪 WikipediaTestAutomation

This is a C# test automation project that compares the content of a specific section ("Test-driven development") between the **Wikipedia UI** and the **Wikipedia API**.

## 🔍 Project Goal

Ensure consistency between the rendered web content and the raw API data for the *Test-driven development* section of the [Wikipedia article on Test automation](https://en.wikipedia.org/wiki/Test_automation).

## 🧾 Assumptions and Limitations

### ✅ Assumptions

- Wikipedia API and UI return the same logical content for the **"Test-driven development"** section.  
- Section titles like **"Test-driven development"** and **"Continuous testing"** are assumed to be stable.  
- The Wikipedia page structure remains consistent during the test period.  

### 🚫 Limitations

- The parser relies on **simple string matching** — if headers are renamed or reordered, extraction may break.  
- **Wiki markup cleaning** uses basic regex and might not cover all edge cases.  
- **Formatting differences** (e.g., hyperlinks as text in UI vs. markup in API) may lead to word count mismatches.  
- Currently supports only the **English version** of the Wikipedia article (fall at any other language).


