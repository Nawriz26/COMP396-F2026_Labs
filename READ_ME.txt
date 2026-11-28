Behavior Web build diagnostic - temporary local package

INSTALL
1. Close Unity.
2. Extract this ZIP into D:\Unity_Projects\COMP396-F2026_Labs.
   The resulting package.json must be at:
   D:\Unity_Projects\COMP396-F2026_Labs\Packages\com.unity.behavior\package.json
   If a Packages\com.unity.behavior folder already exists, do not overwrite it.
3. Reopen Unity and allow compilation to finish.
4. Keep the App UI workaround and Full With Stacktrace enabled.
5. Build And Run into a new empty output folder.
6. Copy Chrome Console messages containing [BEHAVIOR-PROBE-v1], including any exception.
   No diagnostic marker means the browser did not execute this patched initialization path.

PURPOSE
This is a diagnostic, not a completed crash fix. It preserves the supplied Behavior 1.0.17
package and checks graph references before cloning, after cloning, and after node setup.
It identifies null nodes, null child lists, and child cycles with node paths and IDs.
Composite.ResetStatus now throws an explicit exception for a missing child; it does not
silently skip nodes or disable AI. No existing graph asset is edited.

CHANGES
Runtime/Execution/BehaviorGraph.cs: calls the diagnostic around cloning and setup.
Runtime/Execution/BehaviorGraphProbe.cs (+ .meta): reference validation and console markers.
Runtime/Execution/Nodes/Composite.cs: explicit null checks before resetting child nodes.

VALIDATION
Compared all original package files byte-for-byte; only the two source files above changed.
Checked the diagnostic's field and type references against the supplied source.
Unity compilation and browser execution must be checked in your Unity installation;
Unity and a C# compiler are not available in the analysis environment.

UNDO
Close Unity and move ONLY Packages\com.unity.behavior to a backup folder OUTSIDE the
project's Packages folder, then reopen Unity. Package Manager will resolve the registry
version from the existing project dependency settings. Keep Packages\com.unity.dt.app-ui:
that is the separate workaround which made the original linker failure build successfully.
