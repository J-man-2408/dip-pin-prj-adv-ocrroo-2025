# Persona: Alice

## Snapshot

- Name: Alice
- Age: 25
- Occupation: Receptionist
- Location: Perth, Western Australia
- Goals: Learn code and move into a software career
- Motivations: Wants career change into a field she enjoys and wants to learn independently at her own pace
- Frustrations: Has low vision, so she can't reliably read code show in video tutorials
- Technology: Windows laptop, text-to-speech screen reader (NVDA), keyboard-first navigation, high-contrast and large text settings.
- Experience: Confident with screen readers and keyboard shortcuts. New to OCR applications
- Personality: Fun, bubbly, smart
- Interest: Coding, writing, swimming

## Background

Alice works as a receptionist and teaches herself to code in the evenings using free video tutorials. She is comfortable with computers and uses a screen reader every day, so she is not a beginner with assistive technology. Her challenge is the content itself: most coding tutorials show code on screen only, and the presenter rarely reads it aloud. She is not looking for a special "accessibility tool". She wants her tutorials to work like everyone else's.

## Goals

- Pull the code and text shown in a tutorial video into a form her screen reader can read
- Keep the extracted test so she can copy it into her editor and revisit later
- Get through a tutorial without needing someone to read the screen for her

## Needs

- Keyboard use: Every action should work without a mouse, using keyboard shortcuts
- Screen reader friendly: Every button should have a clear name and results and errors should be announced
- Readable text: Large text with strong contrast and no information carried by colour alone.
- Plain output: Extracted text lands in a focusable and read-only area that can be navigated line by line
- Keep and Reuse: Copy a result to the clipboard or download it as a .txt file
- Clear Feedback: A loading message while text is read and a helpful message if no text is found or server cant be reached

## Pain Points

- Code shown only in a visual way in tutorials
- Tools with unlabeled icon buttons
- Errors that appear only as red text or pop up too quick
- Having to repeat steps because results disappear

## How Alice Uses The Application

1. Opens the application with a keyboard and moves through the menu with Tab and arrow keys
2. Plays the demo video and pauses it where code appears on screen
3. Presses the Extract button and hears a "Reading text..." from her screen reader followed by a confirmation
4. Opens the results list where each extraction is its own section with the time is was taken
5. Has her screen reader read the text where she can also download a txt file or copy the information.
6. Deletes any extractions she doesn't need.

## Design Implications

- Uses text labels on buttons as well as icons
- Add `AutomationProperties.Name` to every control
- Announces success and error messages with a "Error:" prefix and colour
- Supports large text and high contrast modes
- Keep the extract action on the player screen so she can extract repeatedly without losing her place.
