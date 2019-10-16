import { format } from 'date-fns';

export default (date: Date) => {
  return format(new Date(date), 'eeee, dd MMMM');
};
