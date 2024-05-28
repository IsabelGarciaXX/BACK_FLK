using Azure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BACK_FLK.Models;

public class DateOnlyConverter : JsonConverter<DateOnly>
{
    private readonly string _format = "yyyy-MM-dd";

    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (DateOnly.TryParseExact(value, _format, out var date))
        {
            return date;
        }
        throw new JsonException("Invalid date format. Expected format is yyyy-MM-dd.");
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(_format));
    }
}



public partial class Servicio
{
    [Key]
    public int PkServicio { get; set; }

    [ForeignKey("TiposServicio")]
    public int? FkTipoServicio { get; set; }

    [Required]
    [JsonConverter(typeof(DateOnlyConverter))]
    public DateOnly? FechaAgendada { get; set; }

    [JsonIgnore]
    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();

    [JsonIgnore]
    public virtual TiposServicio? FkTipoServicioNavigation { get; set; }

    [JsonIgnore]
    public virtual ICollection<Inspeccione> Inspecciones { get; set; } = new List<Inspeccione>();
}


