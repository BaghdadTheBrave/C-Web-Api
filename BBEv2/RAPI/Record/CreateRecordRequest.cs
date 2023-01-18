namespace BBEv2.RAPI.Record;

public record CreateRecordRequest(
    int idUser,
    int idCategory,
    int spent
);