namespace MythApi.Gods.Interfaces;

public interface IGod {
    string Name { get; }
    string Description { get; }
    Mythology Mythology { get; }
}

public enum Mythology {
    Greek,
    Roman,
    Norse,
    Egyptian,
    Celtic,
    Hindu,
    Japanese,
    Chinese,
    Aztec,
    Mayan,
    Incan,
    NativeAmerican,
    African,
    Slavic,
    Baltic,
    Finnish,
    Sumerian,
    Babylonian,
    Assyrian,
    Canaanite,
    Arabian,
    Persian,
    Armenian,
    Georgian,
    Turkic,
    Mongolian,
    Tibetan,
    Vietnamese,
    Korean,
    Philippine,
    Indonesian,
    Polynesian,
    Maori,
    Australian,
    Inuit,
    Hawaiian,
    Mesoamerican,
    JudeoChristian,
    Other
}