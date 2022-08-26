# Kogane Visual Element Extensions Internal

Unity.UI.Builder.VisualElementExtensions の internal な機能にアクセスできるようにするパッケージ

```csharp
var removeButton = root.FindElement( x => x.name == "PackageRemoveCustomButton" );
removeButton.parent.Insert( 0, m_embedButton );
```