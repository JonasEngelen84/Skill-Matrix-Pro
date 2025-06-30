namespace SkillMatrixPro.Domain.Value_Objects
{
    /// <summary>
    /// Repräsentiert das Fähigkeitslevel eines Mitarbeiters (1–5) als Value Object.
    /// Garantiert gültige Werte durch zentrale Validierung im Konstruktor.
    /// </summary>
    public class SkillLevel
    {
        public int Value { get; }

        public SkillLevel(int value)
        {
            if (value < 1 || value > 5)
                throw new ArgumentOutOfRangeException(nameof(value), "Skill Level must be between 1 and 5.");

            Value = value;
        }

        /// <summary>
        /// Ermöglicht die automatische Konvertierung eines SkillLevel in einen int.
        /// Dies erleichtert den Vergleich, die Anzeige und die Verarbeitung von Skill-Werten,
        /// ohne dass explizit auf <c>.Value</c> zugegriffen werden muss.
        /// </summary>
        public static implicit operator int(SkillLevel level) => level?.Value ?? 0;

        /// <summary>
        /// Ermöglicht die explizite Konvertierung eines int in ein SkillLevel.
        /// Ein Cast ist erforderlich, da nicht alle Ganzzahlen gültige Skill-Werte repräsentieren.
        /// Diese Methode stellt sicher, dass die zentrale Validierung angewendet wird.
        /// </summary>
        /// <param name="value">Ein Ganzzahlwert zwischen 1 und 5.</param>
        /// <returns>Ein neues <see cref="SkillLevel"/>-Objekt mit dem übergebenen Wert.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Wird ausgelöst, wenn der Wert außerhalb des gültigen Bereichs (1–5) liegt.
        /// </exception>
        public static explicit operator SkillLevel(int value) => new(value);
    }
}
