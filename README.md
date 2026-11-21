# Overview

OCRRoo is a Python application designed to improve accessibility for people with vision impairments by extracting written text from videos and converting it into a text file.

Videos often contain important information displayed visually on the screen, such as code examples, programming instructions, captions, diagrams containing text, and other written content that may not be spoken aloud.

OCRRoo uses Optical Character Recognition (OCR) to identify and extract this text from video frames. The extracted content can then be saved into a text file, allowing users to access it using their preferred tools, such as screen readers, text-to-speech software, or other assistive technologies.

The project is particularly intended for people with vision impairments who need an alternative way to access information presented visually in educational videos and programming tutorials.

# Core Dependencies

- `OpenCV`
- `NumPy`
- `pytesseract`
- `FastAPI`

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

```bash
git clone <https://github.com/J-man-2408/dip-pin-prj-adv-ocrroo-2025>
```

## Install dependencies using uv

```bash
uv sync
```

# Running the Project

OCRRoo currently provides a library and a FastAPI backend and a Windows desktop frontend. There is no `main.py` entry point.

## FastAPI Development Server

Start the development server from the project root

```bash
uv run fastapi dev preliminary/simple_api.py
```

The API will be available at: `http://127.0.0.1:8000`.

## Available API endpoints

| Method | Endpoint                   | Description                                                                        |
| ------ | -------------------------- | ---------------------------------------------------------------------------------- |
| GET    | /video                     | Lists the videos registered with the API                                           |
| GET    | /video/{vid}               | Returns the metadata about a video, including its FPS, frame count and duration    |
| GET    | /video/{vid}/frame/{t}     | Extracts and returns a video frame as a PNG image at the specified time in seconds |
| GET    | /video/{vid}/frame/{t}/ocr | Extracts a frame and returns the text recognised by Tesseract as plain text        |

# Frontend

OCRRoo includes a Windows desktop frontend built with WPF (C#, .NET). It talks to the FastAPI backend over HTTP, so the backend must be running. The frontend lives in the `OCRRoo-Frontend folder`.

## Frontend Requirements

- Windows
- Visual Studio with the .NEt desktop development workload
- The FastAPI backend running (see Running the Project)

## Running the Frontend

1. Start the FastAPI from the project root
2. Open the solution file in the `OCRRoo-Frontend` folder in Visual Studio.
3. Press F5 to build and run

The frontend expects the backend at `http://127.0.0.1:8000` and uses the hardcoded `demo` video.

## Pages

The MENU button at the top left opens the navigation panel

| Page           | Description                                         |
| -------------- | --------------------------------------------------- |
| Home           | Welcome page                                        |
| OCR Video List | Plays the video with PLAY/PAUSE and EXTRACT buttons |
| Video Results  | Lists every extraction with its file, time and text |
| About Us       | Goal, reason and people behind the project          |

If a frame has no text or the server cannot be reached an error message is shown.

## Current Limitations

- The `UPLOAD` button is a placeholder and does nothing. The video is hardcoded.
- The frontend plays its own copy of the video.mp4 - copied next to the app when it is built - while the backend reads `resources/video.mp4`. Both must be the same video.
- Extractions are kept in memory but lost when the app is closed.
- The server address and the video id (`demo`) are hardcoded.
