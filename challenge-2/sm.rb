ws = ['AValid', 'AnInvalid', 'ANull']
cs = ['NoColumn', 'OneColumn', 'TwoColumns', 'NColumns', 'MColumns', 'ANullColumnList']
rs = ['NoRow', 'OneRow', 'TwoRows', 'NRows', 'ANullRowList']
ts = []
['AndAddA?', 'AndDropA?', 'AndAddN?s', 'AndDropN?s', 'AndDropAll?s'].map do |a|
  o = ''
  ['Row', 'Column'].map do |k|
    ts << a.sub(/\?/, k) + 'DuringWriting'
    o << a.sub(/\?/, k)
  end
  ts << o + 'DuringWriting'
end

ws.map do |w|
  cs.map do |c|
    rs.map do |r|
      cs.map do |v|
        o = "WriteIn#{w}WriterWith#{c}And#{r}With#{v}"
        puts o
        unless o.match(/Null/)
          ts.map do |t|
            puts o + t
          end
        end
      end
    end
  end
end

