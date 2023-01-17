namespace BBEv2.RAPI.Record;

public record GetRecordsResponse(
    List<GetRecordResponse> records
);

public record GetRecordResponse(
    int id,
    int idUser,
    int idCategory,
    DateTime DateTimeOfRecord,
    int spent
);