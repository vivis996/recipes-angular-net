export interface ServiceResponse<Type> {
  success: boolean;
  message: String;
  data: Type;
}
