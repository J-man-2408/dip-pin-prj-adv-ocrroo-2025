# Overview

OCRRoo is a Python application designed to improve accessibility for people with vision impairments by extracting written text from videos and converting it into a text file.

Videos often contain important information displayed visually on the screen, such as code examples, programming instructions, captions, diagrams containing text, and other written content that may not be spoken aloud.

OCRRoo uses Optical Character Recognition (OCR) to identify and extract this text from video frames. The extracted content can then be saved into a text file, allowing users to access it using their preferred tools, such as screen readers, text-to-speech software, or other assistive technologies.

The project is particularly intended for people with vision impairments who need an alternative way to access information presented visually in educational videos and programming tutorials.

# Core Dependencies

- `OpenCV`
- `NumPy`
- `pytesseract`

# External Requirements

## Tesseract OCR

The `pytesseract` library is a Python wrapper and doesn't include the actual Tesseract OCR engine. Therefore Tesseract must be installed separately on the device running this project.

- [Tesseract GitHub](https://github.com/tesseract-ocr/tesseract)
- [Tesseract Installers](https://github.com/UB-Mannheim/tesseract/wiki)

# Installation

## Prerequisites

Before installing OCRRoo ensure you have:

- Python 3.12 or later
- uv installed
- Tesseract OCR installed and configured

## Clone the Repo

``bash
git clone <https://github.com/J-man-2408/dip-pin-prj-adv-ocrroo-2025>

````

## Install dependencies using uv
```bash
uv sync
````

# Running the Project
