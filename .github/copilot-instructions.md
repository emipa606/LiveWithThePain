# Copilot Instruction for RimWorld Modding Project: Live With The Pain

## Mod Overview and Purpose

**Live With The Pain** is a RimWorld mod designed to enhance the realism and complexity of injury management by introducing a system where injuries that cause permanent pain will become less painful over time. This mod reflects the human (and pawn) capacity to adapt to chronic pain and enhances gameplay depth by allowing pawns to learn to cope with their injuries as time progresses. 

The mod is flexible, offering settings adjustments to tailor the experience to the player's preference. It's safe to add or remove from saved games, ensuring compatibility and ease of use.

## Key Features and Systems

- **Pain Reduction Over Time:** 
  - Pain from permanent injuries is automatically reduced as time passes.
  - After five days, pain reduces to 75%.
  - After one quadrum, pain reduces to 50%.
  - After one year, it further reduces to 25%.

- **Enhanced Mod Settings:**
  - Customize when these pain reduction milestones occur.
  - Adjust the level of pain reduction at each milestone.

- **Dynamic Pain Increases:**
  - Pain can increase in certain conditions, adding layers of strategic planning for the player:
    - When pawns are exposed to rain or snow (+100% pain).
    - When temperatures are lower than the seasonal average (+100% pain).
    - Upon waking up, with pain decreasing as rest increases (+100% pain initially).

## Coding Patterns and Conventions

- **Class Naming:** Utilize PascalCase for class names, e.g., `LiveWithThePain`, `LiveWithThePainMod`.
- **Method Naming:** Use PascalCase for method names with descriptive verbs and nouns to clearly articulate their functionality.

## XML Integration

While specific XML file details are not provided, ensure mod settings and data-driven configurations are easily adjusted via XML files. Follow standard RimWorld XML conventions for data declaration, using clear and concise language to describe the function and purpose of each element.

## Harmony Patching

The project should leverage the Harmony library to patch existing RimWorld methods responsibly:

- **Targeting Specific Methods:** Employ Harmony to identify and patch critical methods, enhancing or modifying their workings to reflect the mod's logic.
- **Non-Invasive Patching:** Ensure patches are minimalistic and non-invasive, preserving original game functionality where possible.

## Suggestions for Copilot

To effectively assist with development, Copilot can help by:

- Suggesting code snippets or methods to calculate the reduction in pain over time.
- Providing templates for Harmony patches, ensuring all necessary attributes and conventions are followed.
- Offering XML templates and patterns, particularly for storing customizable settings.
- Generating methods within the `LiveWithThePain` class that implement the logic for dynamic pain increases.
- Assisting in writing tests or debug tools to ensure mod settings behave as expected in different in-game scenarios.

**Note to Developers:** Regularly review and refactor code suggested by Copilot to ensure it aligns with the mod's design principles and employs RimWorld's modding standards effectively.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.
