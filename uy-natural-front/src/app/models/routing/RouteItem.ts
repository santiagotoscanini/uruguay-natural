export interface RouteItem {
  path: string,
  child: RouteItem[],
  class: string,
  text: string,
  method?: Function
}
