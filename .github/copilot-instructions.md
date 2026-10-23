# .github/copilot-instructions.md

## Mod Overview and Purpose

**Mod Name:** Live With The Pain  
**Author:** Mlie  
**Description:**  
This mod enhances the experience of injuries in RimWorld by making them more dynamic over time. Specifically, injuries that cause permanent and usually painful conditions will become less painful as time progresses. This feature simulates pawns' ability to adapt and cope with long-term injuries, enhancing realism within the game.

## Key Features and Systems

- **Pain Adaptation Over Time:** 
  - After 5 days, permanent pain is reduced to 75%.
  - After a quadrum, permanent pain is reduced to 50%.
  - After a year, permanent pain is reduced even further to 25%.

- **Modifiable Settings:**
  - Timing for pain reduction can be adjusted.
  - Customization of pain levels after each stage is allowed.
  - Environmental and situational factors such as rain, snow, and cold can increase pain by 100%.
  - Pain can fluctuate based on wakefulness, increasing by 100% and decreasing as rest replenishes.
  - Options to restrict effects to only controllable pawns.

- **Harmony Patch Used:** The mod relies on the Harmony library by brrainz to facilitate changes and apply patches effectively without altering the core game files.

## Coding Patterns and Conventions

- Maintain clear separation of concerns by organizing code into distinct classes for each primary feature.
- Use descriptive naming conventions for classes and methods to enhance readability and maintainability. For instance, `HediffComp_GetsPermanent_PainFactor` clearly describes its functionality.
- Follow C# coding standards, such as camelCase for method names and PascalCase for class names.

## XML Integration

- The XML file incorporated in the project (`List.xml`) should reflect any changes or configurations necessary for the mod.
- Ensure that all XML files conform to RimWorld's schema and contain accurate pathing to avoid runtime errors.

## Harmony Patching

- Utilize Harmony for non-invasive game modifications, allowing the mod to hook into the game's logic without direct source alterations.
- Postfix methods have been employed in classes like `HediffComp_GetsPermanent_PainFactor` and `Pawn_HealthTracker_HealthTickInterval` to modify behaviors after the original methods are executed.

## Suggestions for Copilot

- Generate methods and classes focusing on the calculation and processing of pain adjustments over time.
- Automate repetitive tasks such as updating pain levels and modifying game state through Harmony patches.
- Produce robust and error-proof code snippets for handling mod settings, ensuring they are correctly read, written, and applied within RimWorld's setting infrastructure.
- Suggest optimization techniques for reducing computational overhead when applying mod features, especially in large-scale colonies. 

This file serves as guidance for how GitHub Copilot can assist in continued development and enhancement of the "Live With The Pain" mod, pushing forward the potential for more immersive and adaptive gameplay experiences.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

