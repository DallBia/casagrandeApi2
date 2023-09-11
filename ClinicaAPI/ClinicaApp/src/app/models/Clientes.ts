export interface Cliente{
  id?: number;
  nome: string;
  mae: string;
  pai: string;
  dtInclusao?: any;
  maeRestric: boolean;
  paiRestric: boolean;
  saSozinho: boolean;
  respFinanc: string;
  identidade: string;
  dtNascim?: any;
  celular: string;
  telFixo: string;
  telComercial: string;
  email: string;
  endereco: string;
  clienteDesde?: any;
  ativo: boolean;
  areaSession: string;
}
