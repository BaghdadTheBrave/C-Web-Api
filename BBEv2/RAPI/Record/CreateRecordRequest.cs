namespace BBEv2.RAPI.Record;

public record CreateRecordRequest(
    int id,
    int idUser,
    int idCategory,
    int spent
);