### Using ZMusic with C#

This is an attempt to call ZMusic from C# by automatically generating a pinvoke wrapper.

### Reference Materials

https://sharovarskyi.com/blog/posts/clangsharp-dotnet-interop-bindings/

### Steps for Generating the pinvoke Wrapper

1. Install ClangSharpPInvokeGenerator and LLVM according to the above reference material.

2. Obtain zmusic.h and the DLLs from the latest release of ZMusic.

3. Execute the following command:

```
ClangSharpPInvokeGenerator `
    -c multi-file generate-file-scoped-namespaces generate-helper-types `
    --file zmusic.h `
    -n ZMusicInterop `
    --libraryPath zmusic.dll `
    --methodClassName ZMusic `
    -o ZMusicInterop
```

4. The generated code includes an undefined type called `_Anonymous_e__Struct`, which prevents the build from succeeding. According to the reference, this can be resolved by mapping the type. However, I took an ad-hoc approach and replaced `_Anonymous_e__Struct` with `void`.
