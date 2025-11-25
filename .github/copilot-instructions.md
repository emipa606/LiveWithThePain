# .github/copilot-instructions.md

## Mod Overview and Purpose

**Mod Name**: Live With The Pain

**Description**: 
The "Live With The Pain" mod enhances the realism and depth of RimWorld by allowing pawns to adapt to permanent injuries over time. Injuries that result in permanent pain will gradually become less painful, as pawns learn to cope with their condition. This mod introduces a dynamic pain reduction system where pain decreases over time as follows:
- After five days, pain reduces to 75%
- After one quadrum, pain reduces to 50%
- After one year, pain reduces further to 25%

This mod also introduces settings for customizing the pain adaptation progression, and environmental factors that can exacerbate pain.

## Key Features and Systems

- **Dynamic Pain Adaptation**: Injuries resulting in permanent pain decrease in severity over time.
- **Mod Settings**: 
  - Configure when pain reduction occurs and by how much.
  - Environmental factors such as rain/snow, temperature deviations, and waking up can temporarily worsen pain.
- **Safe Integration**: The mod is safe to add or remove from existing saves.

## Coding Patterns and Conventions

- **Class Design**: Use of internal and public classes to logically separate functionality.
- **Modular Code Structure**: Each class serves a single purpose, promoting maintainability and clarity.
- **Static and Instance Classes**: 
  - `LiveWithThePain` as a static class for shared logic.
  - `LiveWithThePainMod` and `LiveWithThePainSettings` for mod and settings management.

## XML Integration

- XML files are used for integrating the mod's elements into RimWorld's data-driven systems.
- Ensure that XML tags are consistent with RimWorld's standard schema to avoid load errors.

## Harmony Patching

- Use Harmony to patch existing RimWorld methods to integrate the mod without altering core game files.
- Ensure that patches are non-destructive and reversible to maintain game integrity and allow easy removal.

## Suggestions for Copilot

- Implement suggestions that align with established coding patterns and conventions.
- Generate methods for calculating progressive pain reduction with respect to time.
- Create configurations in `LiveWithThePainSettings` for user-defined settings that adjust pain levels based on external factors.
- Suggest patches that use Harmony to modify pain calculations, leveraging the modular class structure.
- Produce clean and efficient C# code that integrates seamlessly with the existing RimWorld modding framework.

This file provides a comprehensive set of guidelines and details about the "Live With The Pain" mod, offering clarity and instructional support for contributors and AI tools like GitHub Copilot.
