namespace DAL;

public enum StateLoan
{
    //Demande en cours
    PendingRequest,
    //Refusé
    Denied,
    //Validé
    Accepted,
    //Prêt en cours
    Started,

    //Prêt terminé
    Finished

}