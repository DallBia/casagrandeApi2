export interface Colaborador{

    Id?: number;
    Nome: string;
    DtNasc?: string;
    RG?: string;
    CPF?: string;
    Endereco?: string;
    TelFixo?: string;
    Celular?: string;
    Email: string;
    DtAdmis?: string;
    DtDeslig?: string;
    IdPerfil?: number;
    Ativo?: boolean;
    areaSession?: string;
    SenhaHash: string;
}
